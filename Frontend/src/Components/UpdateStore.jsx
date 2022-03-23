import axios from "axios";
import react, { useState } from "react";
import { Button, Modal, Form } from "react-bootstrap";
import { UPDATESTORE } from "../Api/Endpoints";
import Swal from "sweetalert2";
import { storeSchema } from "../Validation/StoreValidation";

const UpdateStore = (storeData) => {
	const [show, setShow] = useState(false);

	const handleClose = () => setShow(false);
	const handleShow = () => setShow(true);

	const [editStore, setEditStore] = useState({
		id: storeData.id,
		companyId: storeData.companyId,
		name: "",
		adress: "",
		city: "",
		zip: "",
		country: "",
		longitude: "",
		latitude: "",
	});

	const validation = async (event) => {
		event.preventDefault();

		let formData = {
			name: event.target[1].value,
			adress: event.target[2].value,
			city: event.target[3].value,
			zip: event.target[4].value,
			country: event.target[5].value,
			longitude: event.target[6].value,
			latitude: event.target[7].value,
		};
		const isValid = await storeSchema.isValid(formData);
		console.log(formData);

		if (isValid) {
			await axios.patch(UPDATESTORE, editStore);
			window.location.reload();
		} else if (!isValid) {
			Swal.fire({
				icon: "error",
				title: "Oops...",
				text: "Please enter correct input!",
				footer: "try again =)",
			});
		}
	};

	const ChangeStoreData = (e) => {
		setEditStore({
			...editStore,
			[e.target.name]: e.target.value,
		});
	};

	const editStores = async () => {
		try {
			const resp = await axios.patch(UPDATESTORE, editStore);
			window.location.reload();
		} catch (error) {
			console.log(error);
		}
	};

	return (
		<>
			<Button variant="primary" onClick={handleShow}>
				Edit Store
			</Button>

			<Modal
				show={show}
				onHide={handleClose}
				backdrop="static"
				keyboard={false}
			>
				<Modal.Header closeButton>
					<Modal.Title>Edit Data</Modal.Title>
				</Modal.Header>
				<Modal.Body>
					<Form onSubmit={validation}>
						<Form.Label htmlFor="inputPassword5">
							CompanyId
						</Form.Label>
						<Form.Control
							type="text"
							name="companyId"
							value={storeData.companyId}
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">Name</Form.Label>
						<Form.Control
							type="text"
							name="name"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">
							Address
						</Form.Label>
						<Form.Control
							type="text"
							name="adress"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">City</Form.Label>
						<Form.Control
							type="text"
							name="city"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">Zip</Form.Label>
						<Form.Control
							type="text"
							name="zip"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">
							Country
						</Form.Label>
						<Form.Control
							type="text"
							name="country"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">
							Longitude
						</Form.Label>
						<Form.Control
							type="text"
							name="longitude"
							onChange={ChangeStoreData}
						/>
						<Form.Label htmlFor="inputPassword5">
							Latitude
						</Form.Label>
						<Form.Control
							type="text"
							name="latitude"
							onChange={ChangeStoreData}
						/>
						<Button type="submit" variant="primary">
							Update
						</Button>
					</Form>
				</Modal.Body>
				<Modal.Footer>
					<Button variant="secondary" onClick={handleClose}>
						Close
					</Button>
				</Modal.Footer>
			</Modal>
		</>
	);
};

export default UpdateStore;
