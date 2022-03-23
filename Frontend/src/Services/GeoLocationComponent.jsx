import React, { Component, useState, useEffect } from "react";
import { YOUR_LATITUDE, YOUR_LONGITUDE } from "../Api/Endpoints";
import Map from "google-maps-react";
import { GoogleApiWrapper, Marker } from "google-maps-react";
import Swal from "sweetalert2";
import { GOAPIKEY, UPDATEPOSITION, GETSTORE } from "../Api/Endpoints";
import axios from "axios";

const mapStyles = {
	width: "1250px",
	height: "800px",
};

const markerHandler = (s) => {
	Swal.fire({
		icon: "info",
		title: s.name,
		text: s.note,
		confirmButtonText: "Change Lat & Lng!!",

		html:
			'<input id="swal-input1" class="swal2-input">' +
			'<input id="swal-input2" class="swal2-input">',
		footer: "Enter Latitude First and Longitude Second",
		focusConfirm: false,
	}).then(() => {
		if (
			document.getElementById("swal-input1").value ||
			document.getElementById("swal-input2").value
		) {
			axios
				.patch(
					UPDATEPOSITION,
					{},
					{
						headers: {
							id: s.id,
							lng: document.getElementById("swal-input1").value,
							lat: document.getElementById("swal-input2").value,
						},
					}
				)
				.then(() => {
					console.log("success");
				});
		}
	});
};
export const GeoLocationComponent = () => {
	const [stores, setStores] = React.useState([]);
	const [centerPosition, setCenterPosition] = React.useState({});

	const fetchData = React.useCallback(async () => {
		try {
			const positions = await axios.get(GETSTORE);
			const data = positions.data;
			setStores(data);

			console.log(stores);
		} catch (e) {
			console.error(e);
		}
	}, []);

	React.useEffect(() => {
		fetchData();

		console.log(stores);
	}, []);

	return (
		<div>
			<Map
				google={stores && stores.google}
				zoom={5}
				style={mapStyles}
				initialCenter={{
					lat: YOUR_LATITUDE,
					lng: YOUR_LONGITUDE,
				}}
			>
				{stores &&
					stores.map((s, k) => {
						return (
							<Marker
								key={k}
								position={{
									lat: s.latitude,
									lng: s.longitude,
								}}
								onClick={() => markerHandler(s)}
							/>
						);
					})}
			</Map>
		</div>
	);
};

export default GoogleApiWrapper({
	apiKey: GOAPIKEY,
})(GeoLocationComponent);
