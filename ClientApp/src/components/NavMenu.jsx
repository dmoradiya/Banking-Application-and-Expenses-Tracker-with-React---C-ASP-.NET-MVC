import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import "./css/NavMenu.css";
import NavDropdown from 'react-bootstrap/NavDropdown'

export class NavMenu extends Component {

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow nav-background" light>
          <Container>
                    <NavbarBrand className="text-dark" tag={Link} to="/landing-page">Capstone_VV</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2 hamburger-icon" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">               
                <NavItem>
                                <NavLink tag={Link} className="text-info" to="/landing-page">Home</NavLink>
                </NavItem>  
                <NavItem>
                    <NavLink tag={Link} className="text-info" to="/create-deposit">Deposit</NavLink>
                </NavItem> 
                <NavItem>
                   <NavLink tag={Link} className="text-info" to="/create-withdraw">Withdraw</NavLink>
                </NavItem> 
                <NavItem>
                    <NavLink tag={Link} className="text-info" to="/pay-bills">Bills</NavLink>
                </NavItem> 
                <NavItem>
                    <NavLink tag={Link} className="text-info" to="/">Logout</NavLink>
                </NavItem>
                    <NavDropdown title="Manage Account" id="basic-nav-dropdown">
                    <NavDropdown.Item href="/add-account">Add Account</NavDropdown.Item>
                    <NavDropdown.Item href="/close-account">Close Account</NavDropdown.Item>
                </NavDropdown>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
