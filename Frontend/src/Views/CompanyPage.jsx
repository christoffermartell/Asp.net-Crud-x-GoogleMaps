import react, { useState, useEffect } from "react";
import { Container, Row, Col } from "react-bootstrap";
import Company from "../Components/Company";

const HomePage = () => {
	return (
		<Container>
			<Row>
				<Col>
					<Company></Company>
				</Col>
			</Row>
		</Container>
	);
};

export default HomePage;
