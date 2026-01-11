import "./App.css";
import { Header } from "./Header";

function App() {
  return (
    <>
      <div className="flex flex-col items-center width-full">
        <Header />
        <h1 className="text-3xl font-bold underline"> Hello world! </h1>
      </div>
    </>
  );
}

export default App;
