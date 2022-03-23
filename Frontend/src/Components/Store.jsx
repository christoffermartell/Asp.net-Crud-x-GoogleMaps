import react, { useState, useEffect } from "react";
import axios from "axios";
import { Container, Row, Col, Card, Button } from "react-bootstrap";
import UpdateStore from "./UpdateStore";
import { GETSTORE, DELETESTORE } from "../Api/Endpoints";

const Store = () => {
	const [store, setStore] = useState([]);

	useEffect(() => {
		sendGetRequest();
	}, []);

	const sendGetRequest = async () => {
		try {
			const resp = await axios.get(GETSTORE);
			console.log(resp.data);
			setStore(resp.data);
		} catch (err) {
			console.error(err);
		}
	};

	const removeStore = async (id) => {
		try {
			await axios.delete(DELETESTORE + id).then((response) => {
				console.log(response);
				if (response) {
					sendGetRequest();
				}
			});
		} catch (error) {
			console.log(error);
		}
	};

	return (
		<Container>
			<Row>
				{store.map((s, i) => {
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
			</Row>
			<Row></Row>
		</Container>
	);
};

export default Store;
