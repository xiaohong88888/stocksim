import { useAuth } from "react-oidc-context";

export const Header = () => {
  const { isAuthenticated, signinRedirect, signoutRedirect, user } = useAuth();

  return (
    <div className="h-auto p-5  font-bold flex bg-(--primary-color) min-w-full justify-between">
      <div>
        <p className="float-left p-2 m-2 text-2xl text-(--secondary-color)">
          Stock Sim
        </p>
      </div>
      <button
        className={
          "float-left px-2 py-3 m-2 text-(--primary-color) bg-(--secondary-color) rounded-[5px] hover:text-(--secondary-color) hover:bg-(--accent-color)"
        }
        onClick={() => (isAuthenticated ? signoutRedirect() : signinRedirect())}
      >
        {isAuthenticated
          ? `Logout userId ${JSON.stringify(user?.profile.sub)}`
          : "Login"}
      </button>
    </div>
  );
};
