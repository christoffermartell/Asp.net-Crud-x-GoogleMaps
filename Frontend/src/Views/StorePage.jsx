import react, { useState, useEffect } from "react";
import { Container, Row, Col } from "react-bootstrap";
import Company from "../Components/Company";
import Store from "../Components/Store";

const StorePage = () => {
	return (
		<Container>
			<Row>
				<Col>
					<Store />
				</Col>
			</Row>
		</Container>
	);
};

export default StorePage;
