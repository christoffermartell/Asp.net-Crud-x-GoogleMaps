import React, { Component } from "react";

class GeoLocation extends Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	componentDidMount() {
		navigator.geolocation.getCurrentPosition(function (position) {
			console.log(position);
			localStorage.setItem("Latitude", position.coords.latitude);
			localStorage.setItem("Longitude", position.coords.longitude);
		});
	}

	render() {
		return <div></div>;
	}
}

export default GeoLocation;
