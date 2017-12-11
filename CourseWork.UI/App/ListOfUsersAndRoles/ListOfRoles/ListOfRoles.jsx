import React from 'react';
import PropTypes from 'prop-types';
import Select from 'react-select';
import createClass from 'create-react-class';
import _ from 'lodash';


export default class ListOfRoles extends React.Component{
    constructor(props) {
        super(props);

        this.state = {
            removeSelected: true,
            stayOpen: true,
            value: '',
            RolesName: this.props.data.role,
            selectedUser: '',
            inactiveRoles: [],
            Roles: [],
            activeRole: []
        }

        this.handleSelectChange = this.handleSelectChange.bind(this);
        this.addRole = this.addRole.bind(this);
        this.loadRoles = this.loadRoles.bind(this);
        this.returnId = this.returnId.bind(this);
    }

    componentDidMount() {
        let self = this;

        window.ee.addListener('SelectedUser', (selectedUser) => {
            this.setState({
                selectedUser: selectedUser
            });
            self.loadRoles(selectedUser);
        });
    };

    componentWillUnmount() {
        window.ee.removeListener('SelectedUser');
    }

    returnId(nameRole) {

        for (let i = 0; i < this.props.data.length; i++) {
                return this.props.data[i].id;
            }
        }

    handleSelectChange(value) {

        let name;
        let activeRole = this.state.activeRole.slice(0, this.state.activeRole.length);
        let lenghtValue = value.length;
        let lengthSelected = this.state.value.length;


        if ((lenghtValue - lengthSelected) >= 0) {

            if (lengthSelected == 0) {
                name = value.substring(lengthSelected, lenghtValue);
                this.state.activeRole.push({ Name: name, Id: this.returnId(name) });
            }
            else {
                name = value.substring(lengthSelected + 1, lenghtValue);
                this.state.activeRole.push({ Name: name, Id: this.returnId(name) });

            }

            this.setState({ value });

            
        }
        else {
            for (let i = 0; i < this.state.activeRole.length; i++) {

                if (!value.includes(this.state.activeRole[i].Name)) {                    
                    this.state.activeRole.splice(i, 1);
                }
            }

            this.setState({ value });
        }                
    };

    addRole() {
        let addedRoles = [];

        for (let i = 0; i < this.props.users.length; i++) {
            if (this.props.users[i].Name == this.state.selectedUser) {
                for (let f = 0; f < this.state.activeRole.length; f++) {
                    
                    this.props.users[i].role.push({
                        Name: this.state.activeRole[f].Name,
                        Id: this.state.activeRole[f].Id
                    });

                    addedRoles.push({
                        Name: this.state.activeRole[f].Name,
                        Id: this.state.activeRole[f].Id
                    });
                }
            }
        }

        window.ee.emit('addedRoles', addedRoles);

        this.setState({
            activeRole: [],
            value: '',
            stayOpen: true
        });

        this.loadRoles(this.state.selectedUser);
        window.ee.emit('userRoles', this.state.selectedUser);
    };

    

    loadRoles(user) {

        let userRoles = [];
        let roles = this.props.data.slice(0, this.props.data.length);

        for (let i = 0; i < this.props.users.length; i++) {
            if (this.props.users[i].Name == user) {
                userRoles = this.props.users[i].role;
            }
        }

        userRoles.map((role, index) => {
            let res = _.find(roles, (o) => { return o.role === role.Name });
            _.pull(roles,res);
        })

        this.setState({
            inactiveRoles: roles
        })
        
    }

    render() {
        const stayOpen = this.state.stayOpen;
        const value = this.state.value;
        const Roles = this.state.Roles.slice(0, this.state.Roles.length);
            

        if (Roles.length == 0) {
            this.state.inactiveRoles.map(function (roles) {
                Roles.push({ label: roles.role, value: roles.role })
            });
        }      


        return (
            <div className="section">

                <h3 className="section-heading">{this.props.name}</h3>
                <Select
                    closeOnSelect={!stayOpen}
                    multi
                    onChange={this.handleSelectChange}
                    options={Roles}
                    placeholder="Select roles"
                    removeSelected={this.state.removeSelected}
                    simpleValue
                    value={value}
                    name="multiselected-state"
                />
                <button className="button" type="button" onClick={this.addRole}>Add role</button>
            </div>
        );
    }
}
