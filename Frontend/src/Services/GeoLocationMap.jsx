import React, { Component, useState } from "react";
import { YOUR_LATITUDE, YOUR_LONGITUDE } from "../Api/Endpoints";
import Map from "google-maps-react";
import { GoogleApiWrapper, Marker } from "google-maps-react";
import Swal from "sweetalert2";
import axios from "axios";
import { GOAPIKEY, UPDATEPOSITION, GETSTORE } from "../Api/Endpoints";
import { LngLatSchema } from "../Validation/StoreValidation";

/*
Denna klass component ger 2 felmeddelanden men renderar ut Google maps korrekt,
"GeolocationComponent" renderar inga felmeddelanden men kan inte rendera kartan.
"GeolocationComponent" används inte i "Company - filen" //Applikationen  för tillfället.
*/

const mapStyles = {
	width: "1250px",
	height: "800px",
};

const markerHandler = async (s) => {
	Swal.fire({
		icon: "info",
		title: s.name,
		text: s.note,
		confirmButtonText: "Change Lat & Lng!!",

		html:
			'<input id="swal-input1" class="swal1-input">' +
			'<input id="swal-input2" class="swal1-input">',
		footer: "Enter Latitude First and Longitude Second",
		focusConfirm: false,
	}).then(() => {
		if (
			document.getElementById("swal-input1").value ||
			document.getElementById("swal-input2").value
		) {
			let formData = {
				longitude: document.getElementById("swal-input1").value,
				latitude: document.getElementById("swal-input2").value,
			};
			LngLatSchema.isValid(formData).then((x) => {
				Promise.resolve(x).then(() => {
					if (x) {
						axios
							.patch(
								UPDATEPOSITION,
								{},
								{
									headers: {
										id: s.id,
										lng: document.getElementById(
											"swal-input1"
										).value,
										lat: document.getElementById(
											"swal-input2"
										).value,
									},
								}
							)
							.then(() => {
								console.log("success");

								window.location.reload();
							});
					} else {
						Swal.fire({
							icon: "error",
							title: "Oops...",
							text: "Please enter correct input!",
							footer: "try again =)",
						});
					}
				});
			});

			/*
			console.log(x);
			if ((x = true)) {
				console.log("true lol");
			} else {
				console.log("False lol");
			}
			*/

			/*	axios
					.patch(
						UPDATEPOSITION,
						{},
						{
							headers: {
								id: s.id,
								lng: document.getElementById("swal-input1")
									.value,
								lat: document.getElementById("swal-input2")
									.value,
							},
						}
					)
					.then(() => {
						console.log("success");

						window.location.reload();
					});*/
		}
	});
};

class GeoMap extends Component {
	constructor(props) {
		super(props);
		this.state = {
			stores: [],
		};
	}

	componentDidMount() {
		axios
			.get(GETSTORE)
			.then((resp) => this.setState({ stores: resp.data }));
	}

	render() {
		return (
			<div>
				<Map
					google={this.props.google}
					zoom={5}
					style={mapStyles}
					initialCenter={{
						lat: YOUR_LATITUDE,
						lng: YOUR_LONGITUDE,
					}}
				>
					{this.state.stores.map((s, k) => {
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
	}
}

export default GoogleApiWrapper({
	apiKey: GOAPIKEY,
})(GeoMap);
