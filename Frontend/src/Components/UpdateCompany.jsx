import axios from "axios";
import react, { useState } from "react";
import { Button, Modal, Form } from "react-bootstrap";
import { UPDATECOMPANIES } from "../Api/Endpoints";
import { companySchema } from "../Validation/StoreValidation";
import Swal from "sweetalert2";

const UpdateCompany = (companyData) => {
	const [show, setShow] = useState(false);

	const handleClose = () => setShow(false);
	const handleShow = () => setShow(true);

	const [editCompany, setEditCompany] = useState({
		id: companyData.id,
		name: "",
		organizationnumberId: "",
		note: "",
		stores: [],
	});

	const ChangeCompanyData = (e) => {
		setEditCompany({
			...editCompany,
			[e.target.name]: e.target.value,
		});
	};

	const validation = async (event) => {
		event.preventDefault();

		let formData = {
			name: event.target[0].value,
			organizationnumberId: event.target[1].value,
			note: "",
		};
		const isValid = await companySchema.isValid(formData);

		if (isValid) {
			await axios.patch(UPDATECOMPANIES, editCompany);
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

	return (
		<>
			<Button variant="primary" onClick={handleShow}>
				Edit Company
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
						<Form.Label htmlFor="inputPassword5">Name</Form.Label>
						<Form.Control
							type="text"
							name="name"
							onChange={ChangeCompanyData}
						/>
						<Form.Label htmlFor="inputPassword5">
							Organizationnumber
						</Form.Label>
						<Form.Control
							type="text"
							name="organizationnumber"
							onChange={ChangeCompanyData}
						/>
						<Form.Label htmlFor="inputPassword5">Notes</Form.Label>
						<Form.Control
							as="textarea"
							placeholder="Enter notes here"
							name="notes"
							onChange={ChangeCompanyData}
							style={{ height: "100px" }}
						/>
						<Button type="submit" variant="primary">
							Update
						</Button>
					</Form>
				</Modal.Body>
				<Modal.Footer>
					<Button variant="secondary" onClick={handleClose}>
						Cancel
					</Button>
				</Modal.Footer>
			</Modal>
		</>
	);
};

export default UpdateCompany;
