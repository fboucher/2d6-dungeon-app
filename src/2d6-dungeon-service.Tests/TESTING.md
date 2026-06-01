# 2D6 Dungeon Service - Testing Guide

## Overview

This test project (`2d6-dungeon-service.Tests`) uses xUnit to verify core game logic with a focus on deterministic, isolated unit tests.

## Testing Patterns

### 1. Mocking Static Delegates (DiceResult.RollDie)

**Problem**: Dice rolls are random, making tests non-deterministic.

**Solution**: `DiceResult.RollDie` is a static `Func<int>` that can be replaced with predictable implementations.

```csharp
// Example: Force a specific dice value
try
{
    DiceResult.RollDie = () => 6;
    var result = DiceResult.Roll2Dice();
    Assert.Equal(6, result.PrimaryDice);
    Assert.Equal(6, result.SecondaryDice);
}
finally
{
    ResetRollDie(); // Always reset to prevent side effects
}
```

**Important**: Always reset `RollDie` in a `finally` block to prevent affecting other tests.

### 2. Dependency Injection via Interfaces (ID6Service)

**Problem**: GameTurn depends on D6Service, which queries the database. Tests need to isolate logic.

**Solution**: GameTurn uses `ID6Service?` interface, allowing tests to inject `MockD6Service`.

```csharp
var mockService = new MockD6Service();
mockService.RollRoomFunc = (roll, size) => Task.FromResult(new Room { id = 42 });

var gameTurn = new GameTurn { d6Service = mockService };
var result = await gameTurn.ContinueTurn(diceResult, dungeon);
```

### 3. Extending MockD6Service

When adding tests that require new D6Service functionality:

1. Add the method signature to `MockD6Service` (remove `throw new NotImplementedException()`)
2. Add a configurable `Func<...>` property (like `RollRoomFunc`)
3. Update the docstring explaining when to extend this mock

```csharp
// Example: Adding support for GetWeapons
public Func<Task<WeaponList>>? GetWeaponsFunc { get; set; }

public Task<WeaponList> GetWeapons()
{
    if (GetWeaponsFunc != null) return GetWeaponsFunc();
    return Task.FromResult(new WeaponList { /* defaults */ });
}
```

## Test Organization

| Class | Purpose | Key Patterns |
|-------|---------|--------------|
| **DiceResultTests** | Dice rolling classification | Mocked RollDie delegate, try-finally cleanup |
| **AdventurerTests** | Character initialization | Constructor overloads, serialization roundtrips |
| **DungeonTests** | Room generation logic | Area threshold calculations |
| **GameTurnTests** | Game state machine | ID6Service mocking, deterministic re-roll scenarios |

## Best Practices

✅ **DO:**
- Use try-finally to reset mocks after each test
- Name tests descriptively: `Method_Scenario_ExpectedBehavior`
- Use Arrange-Act-Assert pattern
- Test edge cases (area boundaries, re-roll limits)
- Document why NotImplementedExceptions exist in MockD6Service

❌ **DON'T:**
- Rely on IDisposable cleanup (favor try-finally for clarity)
- Test multiple scenarios in one test
- Leave mocks in a modified state between tests
- Hard-code magic numbers—add explanatory comments

## Running Tests

```bash
# From src/ directory
dotnet test

# Run specific test file
dotnet test --filter "ClassName=GameTurnTests"

# Run with verbose output
dotnet test --verbosity normal
```

## Common Issues

### Tests Fail Intermittently
**Cause**: RollDie wasn't reset in a finally block.  
**Fix**: Wrap mock assignments in try-finally, use `ResetRollDie()`.

### "Cannot modify sealed class" errors
**Cause**: Trying to mock non-virtual methods or sealed classes.  
**Fix**: Use dependency injection (ID6Service pattern) instead.

### MockD6Service Throws NotImplementedException
**Cause**: Test is calling a method that hasn't been implemented in the mock.  
**Fix**: Add the method to MockD6Service, or reconsider if the test should use a different approach.

## Adding New Tests

When adding a new test class:

1. Add XML documentation explaining what it tests
2. Follow the naming convention: `ClassName + Tests`
3. Use try-finally for any RollDie modifications
4. Add the class to the TestCases section in this README

## Future Enhancements

- [ ] Create base test class for shared RollDie reset logic
- [ ] Add integration tests for D6Service with test database
- [ ] Add property-based tests using FsCheck for game mechanics
