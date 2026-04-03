# Work Routing

## Routing Table

| Work Type | Route To | Examples |
|-----------|----------|----------|
| Architecture, scope, code review, decisions | Dallas | What to build, trade-offs, PR review |
| Backend / game logic / .NET / data / API | Ripley | GameTurn, 2D6Engine, data tables, services |
| Frontend / Blazor UI / components / canvas | Lambert | .razor components, CSS, UI interactions |
| Testing / QA / edge cases | Hicks | Unit tests, integration tests, acceptance criteria |
| Session logging | Scribe | Automatic — never needs routing |
| Work queue monitoring | Ralph | GitHub issues, PRs, backlog |

## Issue Routing

| Label | Action | Who |
|-------|--------|-----|
| `squad` | Triage: analyze issue, assign `squad:{member}` label | Dallas |
| `squad:dallas` | Pick up issue and complete the work | Dallas |
| `squad:ripley` | Pick up issue and complete the work | Ripley |
| `squad:lambert` | Pick up issue and complete the work | Lambert |
| `squad:hicks` | Pick up issue and complete the work | Hicks |
