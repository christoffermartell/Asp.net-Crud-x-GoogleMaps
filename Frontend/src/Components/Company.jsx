import React, { useState, useEffect } from "react";
import axios from "axios";
import { Container, Row, Col, Card, Button } from "react-bootstrap";
import CreateCompanyForm from "./CreateCompanyForm";
import UpdateCompany from "./UpdateCompany";
import { useNavigate } from "react-router-dom";
import CompanyDetails from "./CompanyDetails";
import CreateStoreModal from "./CreateStoreModal";
import GeoLocationMap from "../Services/GeoLocationMap";
import GeoLocationComponent from "../Services/GeoLocationComponent";
import GeoMap from "../Services/GeoLocationMap";
import { COMPANIES, DELETECOMPANIES } from "../Api/Endpoints";
const Company = () => {
	const [companies, setCompanies] = useState([]);

	const sendGetRequest = async () => {
		try {
			const resp = await axios.get(COMPANIES);

			setCompanies(resp.data);
		} catch (err) {
			console.error(err);
		}
	};

	const removeCompany = async (id) => {
		try {
			await axios.delete(DELETECOMPANIES + id).then((response) => {
				if (response) {
					sendGetRequest();
				}
			});
		} catch (error) {
			console.log(error);
		}
	};

	useEffect(() => {
		sendGetRequest();
	}, []);

	return (
		<Container>
			<Row>
				<CreateCompanyForm />
			</Row>
			{companies.map((c, i) => {
				return (
					<div key={i}>
						<Container>
							<Row>
								<Card className="text-center">
									<Card.Header>
										{c.organizationNumber}
									</Card.Header>
									<Card.Body>
										<Card.Title>{c.name}</Card.Title>
										<Card.Text>{c.notes}</Card.Text>
										<Button
											onClick={() => removeCompany(c.id)}
											variant="outline-secondary"
										>
											Remove
										</Button>{" "}
										<UpdateCompany
											id={c.id}
											name={c.name}
											organizationNumber={
												c.organizationNumber
											}
											notes={c.notes}
										></UpdateCompany>
										<CreateStoreModal
											id={c.id}
										></CreateStoreModal>
										<Row>
											<CompanyDetails id={c.id} />
										</Row>
									</Card.Body>
								</Card>
							</Row>
						</Container>
					</div>
				);
			})}
			<Col>
				{/* 
					<GeoLocationComponent />
				*/}
				<GeoLocationMap />
			</Col>
		</Container>
	);
};

export default Company;
