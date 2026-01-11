import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";

// ... andere imports
import { AuthProvider } from "react-oidc-context";
import type { UserManagerSettings } from "oidc-client-ts";

const settings: UserManagerSettings = {
  authority: "https://localhost:5001",
  client_id: "stocksim.frontend",
  client_secret: "eenfrontendgeheim",
  redirect_uri: "http://localhost:5173/",
  response_type: "code",
  scope: "openid profile stocksim.priceapi.read",
  monitorSession: true,
};

const onSigninCallback = (): void => {
  window.history.replaceState({}, document.title, window.location.pathname);
};

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <AuthProvider {...settings} onSigninCallback={onSigninCallback}>
      <App />
    </AuthProvider>
  </StrictMode>
);
