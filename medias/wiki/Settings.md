# Customizing Application Settings & Debugging ⚙️

The **2D6 Dungeon Companion App** is highly configurable, allowing you to customize your user interface preferences, configure database connections, manage environment rules, and view developer debugging logs. 

This guide details how to customize these settings and how developers can utilize logs to troubleshoot the system.

---

## 🎨 User Preferences & UI Themes

You can customize your visual experience directly inside the app by clicking **Settings** in the navigation sidebar.

### 1. Theme Mode
The app leverages the `<FluentDesignTheme>` component to allow three distinct visual modes:
* **System (Default):** Matches your operating system or browser light/dark setting.
* **Light:** Enforces high-contrast light mode.
* **Dark:** Enforces eye-friendly dark mode.

### 2. Office Color Palettes
You can select a standard **Office Color** theme (e.g., standard Microsoft Office accent colors) to colorize interactive Fluent UI elements such as inputs, buttons, and navigation badges.

### 3. Custom "Dungeon" Theme
To fully immerse yourself in the dungeon-crawling atmosphere, select the custom **Dungeon Theme**:
* **Accent Color:** Applying a rustic wood-and-stone style (#4A3728).
* **Styling Class:** Injecting a custom CSS class `dungeon-theme` to `document.body` via dynamic JavaScript interoperability (`JSRuntime`). This activates custom game-oriented backgrounds, borders, and textures.

> 💾 **Persistence Notice:** All UI preferences are saved inside your browser's local storage under the key `theme`. This ensures your theme and colors remain active whenever you close and reopen the app.

---

## 🗄️ Database Settings & Environments

The app runs on a distributed architecture utilizing a **MySQL 8.0** server, Azure **Data API Builder (DAB)**, and a **Blazor WebApp** front-end. 

### 1. The Environment Configuration File (`.env`)
Database credentials and ports are managed externally in the root `.env` file. You can change these configurations in any text editor before starting the app:

```env
# Database Credentials & Port Exposure
MYSQL_ROOT_PASSWORD=localdev123
MYSQL_DATABASE=db2d6
MYSQL_PORT=3306

# Exposed API and Web Server Ports
DAB_PORT=5000
WEBAPP_PORT=8080

# Environment Mode (Development or Production)
ASPNETCORE_ENVIRONMENT=Production
```

### 2. Campaign Data Persistence
Your adventurers, map progress, active combats, and rules are safely persisted in a Docker volume:
* **Volume Name:** `db_data` (Docker Compose usually namespaces this as `2d6-dungeon_db_data`)
* **Lifecycle:** When stopping or recreating containers (`docker compose down` or `docker compose up`), your database volume is **never** deleted. Your campaign state is preserved. To reset all campaign data completely, run `docker compose down -v`.

### 3. Automatic Database Initialization
On the initial run, the MySQL container automatically executes any SQL scripts located in `./database/scripts/`. This configures the complete schema, tables, and seed metadata automatically. 

### 4. Data API Builder (DAB) Configuration
The Azure Data API Builder acts as the bridge, exposing the MySQL database via standard REST and GraphQL endpoints for the web client. Its behavior is controlled by the configuration file:
* **Path:** `/home/frank/gh/2d6-dungeon-app/database/dab-config.json`
* **Connection String:** DAB retrieves its connection details dynamically via environment variables configured in `docker-compose.yml` (`ConnectionStrings__db2d6`).

---

## 🛠️ Developer Debugging Logs & Diagnostics

Developers and power users can utilize logging and environment configurations to trace issues, inspect database queries, or troubleshoot Blazor state.

### 1. Inspecting Live Container Logs
Because the app runs in separate Docker containers, you can stream service logs directly from your terminal:

```bash
# View and follow logs from ALL services
docker compose logs -f

# View only the Blazor Web Client logs
docker compose logs webapp -f

# View only Azure Data API Builder logs (great for database queries)
docker compose logs dab -f

# View only MySQL server engine logs
docker compose logs mysql -f
```

### 2. Configuring ASP.NET Core Log Levels
By default, standard logs are outputted at the `Information` level. You can customize this by overriding log levels dynamically using environment variables in `.env` or `docker-compose.yml`:

* **Change Global Level to Debug:** Set `Logging__LogLevel__Default=Debug`
* **Change ASP.NET engine logs to Warning only:** Set `Logging__LogLevel__Microsoft__AspNetCore=Warning`

### 3. Detailed Errors & Blazor Diagnostics
When troubleshooting interactive UI errors:
1. Ensure `ASPNETCORE_ENVIRONMENT=Development` is set in your `.env`.
2. This activates detailed error screens (`DetailedErrors: true`), exposing full exception stack traces directly on the client.
3. Open your browser's Developer Tools Console (**F12** or `Ctrl+Shift+I` / `Cmd+Option+I`) to inspect for JavaScript interoperability failures, WebAssembly/Server circuit disconnects, or unhandled exceptions.
