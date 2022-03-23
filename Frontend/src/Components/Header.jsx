import react from "react";
import { Navbar, Container, Nav } from "react-bootstrap";

const Header = () => {
	return (
		<>
			<Navbar bg="light" variant="light">
				<Container>
					<Navbar.Brand>Consid Exercise</Navbar.Brand>
					<Nav className="me-auto">
						<Nav.Link href="/">Companies</Nav.Link>
						<Nav.Link href="/stores">Stores</Nav.Link>
					</Nav>
				</Container>
			</Navbar>
		</>
	);
};
export default Header;
