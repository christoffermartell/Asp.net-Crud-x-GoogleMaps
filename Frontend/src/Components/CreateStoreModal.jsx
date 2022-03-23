import axios from "axios";
import react, { useState } from "react";
import { Button, Modal, Form, Row } from "react-bootstrap";
import { ADDSTORE } from "../Api/Endpoints";
import { storeSchema } from "../Validation/StoreValidation";
import Swal from "sweetalert2";

const CreateStoreModal = (companyData) => {
	const [show, setShow] = useState(false);
	const handleClose = () => setShow(false);
	const handleShow = () => setShow(true);
	const [createStore, setCreateStore] = useState({
		companyId: companyData.id,
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
			name: event.target[0].value,
			adress: event.target[1].value,
			city: event.target[2].value,
			zip: event.target[3].value,
			country: event.target[4].value,
			longitude: event.target[5].value,
			latitude: event.target[6].value,
		};
		const isValid = await storeSchema.isValid(formData);

		if (isValid) {
			axios.post(ADDSTORE, createStore);
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

	const changePostData = (e) => {
		setCreateStore({
			...createStore,
			[e.target.name]: e.target.value,
		});
	};

	return (
		<>
			<Button variant="primary" onClick={handleShow}>
				Create Store
			</Button>

			<Modal show={show} onHide={handleClose} animation={false}>
				<Modal.Header closeButton>
					<Modal.Title>Modal heading</Modal.Title>
				</Modal.Header>
				<Modal.Body>
					<Form onSubmit={validation}>
						<Form.Floating>
							<Form.Control
								type="text"
								placeholder="1234"
								name="name"
								onChange={changePostData}
								required
							/>
							<label htmlFor="floatingInputCustom">Name</label>
						</Form.Floating>
						<Form.Floating>
							<Form.Control
								type="text"
								placeholder="1234"
								name="adress"
								onChange={changePostData}
								required
							/>
							<label htmlFor="floatingInputCustom">Adress</label>
						</Form.Floating>
						<Row>
							<Form.Floating>
								<Form.Control
									type="text"
									placeholder="1234"
									name="city"
									onChange={changePostData}
									required
								/>
								<label htmlFor="floatingInputCustom">
									city
								</label>
							</Form.Floating>

							<Form.Floating>
								<Form.Control
									type="text"
									placeholder="1234"
									name="zip"
									onChange={changePostData}
									required
								/>
								<label htmlFor="floatingInputCustom">Zip</label>
							</Form.Floating>

							<Form.Floating>
								<Form.Control
									type="text"
									placeholder="1234"
									name="country"
									onChange={changePostData}
									required
								/>
								<label htmlFor="floatingInputCustom">
									Country
								</label>
							</Form.Floating>

							<Form.Floating>
								<Form.Control
									type="text"
									placeholder="1234"
									name="longitude"
									onChange={changePostData}
									required
								/>
								<label htmlFor="floatingInputCustom">
									Longitude
								</label>
							</Form.Floating>

							<Form.Floating>
								<Form.Control
									type="text"
									placeholder="1234"
									name="latitude"
									onChange={changePostData}
									required
								/>
								<label htmlFor="floatingInputCustom">
									Latitude
								</label>
							</Form.Floating>
						</Row>
						<Button type="submit" variant="outline-secondary">
							Create
						</Button>{" "}
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

export default CreateStoreModal;
