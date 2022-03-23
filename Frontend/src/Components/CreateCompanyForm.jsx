import react, { useState } from "react";
import axios from "axios";
import {
	Container,
	Row,
	Col,
	Card,
	Form,
	FloatingLabel,
	Button,
} from "react-bootstrap";
import { COMPANIES } from "../Api/Endpoints";
import { companySchema } from "../Validation/StoreValidation";
import Swal from "sweetalert2";

const CreateCompanyForm = () => {
	const [createCompany, setCreateCompany] = useState({
		name: "",
		organizationnumberId: "",
		note: "",
		stores: [],
	});

	const changePostData = (e) => {
		setCreateCompany({
			...createCompany,
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
			await axios.post(COMPANIES, createCompany);
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
		<Container>
			<Row>
				<Card style={{ width: "90rem" }}>
					<Card.Title>Create Company</Card.Title>
					<Card.Body>
						<Form onSubmit={validation}>
							<Col>
								<Form.Floating className="mb-3">
									<Form.Control
										id="floatingInputCustom"
										type="text"
										placeholder="Consid"
										name="name"
										onChange={changePostData}
										required
									/>
									<label htmlFor="floatingInputCustom">
										Name
									</label>
								</Form.Floating>
							</Col>
							<Col>
								<Form.Floating>
									<Form.Control
										id="floatingPasswordCustom"
										type="text"
										placeholder="1234"
										name="organizationnumber"
										onChange={changePostData}
										required
									/>
									<label htmlFor="floatingInputCustom">
										OrganizationNumber
									</label>
								</Form.Floating>
							</Col>
							<Row>
								<FloatingLabel
									controlId="floatingTextarea2"
									label="Notes"
								>
									<Form.Control
										as="textarea"
										placeholder="Enter notes here"
										name="notes"
										onChange={changePostData}
										style={{ height: "100px" }}
									/>
								</FloatingLabel>
							</Row>
							<Button type="submit" variant="outline-secondary">
								Create
							</Button>{" "}
						</Form>
					</Card.Body>
				</Card>
			</Row>
		</Container>
	);
};

export default CreateCompanyForm;
