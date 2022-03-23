import react, { useState, useEffect } from "react";
import axios from "axios";
import { Col, Card, Button } from "react-bootstrap";
import UpdateStore from "./UpdateStore";
import { GETSTORESOFCOMPANY, DELETESTORE } from "../Api/Endpoints";

const CompanyDetails = (data) => {
	const [stores, setStores] = useState([]);

	useEffect(() => {
		sendGetRequest();
	}, []);

	const sendGetRequest = async () => {
		try {
			const resp = await axios.get(GETSTORESOFCOMPANY + data.id);

			setStores(resp.data);
		} catch (err) {
			console.error(err);
		}
	};

	const removeStore = async (id) => {
		try {
			await axios.delete(DELETESTORE + id).then((response) => {
				if (response) {
					sendGetRequest();
				}
			});
		} catch (error) {
			console.log(error);
		}
	};

	return (
		<div>
			{stores.map((s, i) => {
				return (
					<Col key={i}>
						<Card style={{ width: "18rem" }}>
							<Card.Body>
								<Card.Title>{s.name}</Card.Title>
								<Card.Text>{s.adress}</Card.Text>
								<Card.Text>{s.city}</Card.Text>
								<Card.Text>{s.zip}</Card.Text>
								<Card.Text>{s.country}</Card.Text>
								<Card.Text>{s.longitude}</Card.Text>
								<Card.Text>{s.latitude}</Card.Text>
								<Button
									onClick={() => removeStore(s.id)}
									variant="outline-secondary"
								>
									Remove
								</Button>{" "}
								<UpdateStore
									id={s.id}
									companyId={s.companyId}
									name={s.name}
									adress={s.adress}
									city={s.city}
									zip={s.zip}
									country={s.country}
									latitude={s.latitude}
									longitude={s.longitude}
								></UpdateStore>
							</Card.Body>
						</Card>
					</Col>
				);
			})}
		</div>
	);
};

export default CompanyDetails;
