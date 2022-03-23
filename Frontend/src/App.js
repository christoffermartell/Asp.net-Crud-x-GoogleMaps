import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import Header from "./Components/Header";
import RouteConfig from "./Api/RouteConfig";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import GeoLocation from "./Services/GeoLocation";

function App() {
	return (
		<Router>
			<Header />
			<GeoLocation />

			<Routes>
				{RouteConfig.map((route) => (
					<Route
						key={route.path}
						path={route.path}
						element={route.component}
					></Route>
				))}
			</Routes>
		</Router>
	);
}

export default App;
