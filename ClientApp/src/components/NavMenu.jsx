import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

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
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand className="text-light" tag={Link} to="/">Capstone_VV</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/create-account-for-existing-client">Create Account for Exisitng Client</NavLink>
                </NavItem>
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/landing-page">Landing Page</NavLink>
                </NavItem>  
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/create-deposit">Deposit</NavLink>
                </NavItem> 
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/create-withdraw">Withdraw</NavLink>
                </NavItem> 
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/pay-bills">Pay Bills</NavLink>
                </NavItem> 
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/">Logout</NavLink>
                </NavItem> 
                <NavItem>
                                <NavLink tag={Link} className="text-light" to="/close-account">Close Account</NavLink>
                </NavItem> 
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
