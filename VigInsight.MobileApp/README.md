# VigInsight Mobile App (React Native)

React Native (Expo) mobile app created from the `UIPages` flow and wired to the existing `.NET 8` API project.

## Screen coverage mapped from `UIPages`

- `index.html` -> `LoginScreen`
- `AdminDashboard.html` -> `AdminDashboardScreen`
- `ClientDashboard.html` -> `ClientDashboardScreen`
- `UserList.html` / `AddUser.html` -> `UsersScreen`
- `MachineList.html` / `AddMachine.html` -> `MachinesScreen`
- `OrganizationList.html` / `AddOrganization.html` -> `OrganizationsScreen`
- `MachineOverview.html` + `Page2..Page53.html` -> `MachinePagesScreen` + `PageDataScreen`

## Tech choices

- Expo + React Native + TypeScript
- React Navigation (stack + tabs)
- Async storage for persisted JWT session
- Existing backend APIs (`/api/Login`, `/api/User`, `/api/Machine`, `/api/Organization`, `/api/Role`, `/api/PageData`)

## Setup

1. In `VigInsight.MobileApp`, install packages:
   - `npm install`
2. Configure API URL:
   - copy `.env.example` to `.env`
   - set `EXPO_PUBLIC_API_BASE_URL`
3. Start app:
   - `npm run start`

## Notes

- For Android emulator, replace `localhost` with `10.0.2.2`.
- For physical devices, use your machine LAN IP.
- JWT is attached automatically after login.
- Role-based tabs are enabled (`Admin`, `Client`, `User`).
