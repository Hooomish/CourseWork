import React from 'react';
import PropTypes from 'prop-types';
import Select from 'react-select';
import createClass from 'create-react-class';



export default class ListOfUsers extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            searchable: true,
            selectValue: '',
            users: this.props.data,
            selectedUser: {}
        }

        this.updateValue = this.updateValue.bind(this);
        this.addRoles = this.addRoles.bind(this);
        this.admin = this.admin.bind(this);
    }
    

    switchCountry(e) {
        this.setState({
            selectValue: null
        });
    };

    updateValue(newValue) {
        this.setState({
            selectValue: newValue,
        });

        window.ee.emit('userRoles', newValue);
        window.ee.emit('SelectedUser', newValue);

        for (let i = 0; i < this.props.data.length; i++) {
            if (this.props.data[i].Name == newValue) {
                window.ee.emit('SelectedUserId', this.props.data[i].id);
                break;
            }
        }
    };

    focusStateSelect() {
        this.refs.stateSelect.focus();
    };

    componentDidMount() {
        let self = this;
        
        window.ee.addListener('AddRoles', (addRole) => {
            self.addRoles(addRole);            
        });

    };

    addRoles(roles) {
        let selectUser = {};
        let selectRoles = [];
        
        for (let i = 0; i < this.props.data.length; i++){
            if (this.props.data[i].Name == this.state.selectValue) {                
                this.props.data[i].role.push({ Name: roles });                
            }
        }        
    }    


    render() {
        const Users = [];



        window.ee.emit('Users', this.props.data);

        if (Users.length == 0) {
            this.props.data.map(function (user) {
                Users.push({ label: user.Name, value: user.Name })
            });
        }

        return (
            <div className="section">
                <h3 className="section-heading">{this.props.name}</h3>
                <Select
                    id="state-select"
                    ref="stateSelect"
                    autoFocus
                    options={Users}
                    simpleValue
                    name="selected-users"
                    value={this.state.selectValue}
                    onChange={this.updateValue}
                    openOnClick={false}
                    searchable={this.state.searchable}
                />
                </div>
            );

    }

}





