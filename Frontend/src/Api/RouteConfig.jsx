import React from "react";
import CompanyDetails from "../Components/CompanyDetails";
import CompanyPage from "../Views/CompanyPage";
import StorePage from "../Views/StorePage";

const RouteConfig = [
	{
		path: "/",
		component: <CompanyPage />,
	},
	{
		path: "/stores",
		component: <StorePage />,
	},
	{
		path: "/:name",
		component: <CompanyDetails />,
	},
];

export default RouteConfig;
