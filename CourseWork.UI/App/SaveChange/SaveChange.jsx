import React from 'react';

const serverUrl = 'http://localhost:52367/';

export default class SaveChange extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            selectedUserId: '',
            removeRoles: [],
            addedRoles: []
        }

        this.changeRoles = this.changeRoles.bind(this);
        this.addRole = this.addRole.bind(this);
        this.removeRole = this.removeRole.bind(this);
        this.sendChangeRolesToServer = this.sendChangeRolesToServer.bind(this);
    }

    componentDidMount() {
        let self = this;

        window.ee.addListener('removeRoles', (loadRoles) => {
            self.removeRole(loadRoles);            
        });

        window.ee.addListener('addedRoles', (loadRoles) => {
            self.addRole(loadRoles);
        });

        window.ee.addListener('SelectedUserId', (loadUserId) => {
            this.setState({
                selectedUserId: loadUserId,
                addedRoles: [],
                removeRoles: []
            })
        });
    };

    componentWillUnmount() {
        window.ee.removeListener('SelectedUserId');
        window.ee.removeListener('removeRolesFromUserRoles');
        window.ee.removeListener('addedRolesFromUserRoles');
    }

    addRole(addRoles) {

        let removeRoles = this.state.removeRoles.slice(0, this.state.removeRoles.length);
        let addedRoles = this.state.addedRoles.slice(0, this.state.addedRoles.length);
        let similar = false;

        for (let i = 0; i < addRoles.length; i++) {
            similar = false;
            for (let j = 0; j < removeRoles.length; j++) {
                if (addRoles[i].Name == removeRoles[j].Name) {
                    similar = true;
                    removeRoles.splice(j, 1);
                    break;
                }
            }
            if (!similar) {
                addedRoles.push({ Name: addRoles[i].Name, Id: addRoles[i].Id });
            }
        }

        this.setState({
            addedRoles: addedRoles,
            removeRoles: removeRoles
        });
    }

    removeRole(removeRole) {
        let removeRoles = this.state.removeRoles.slice(0, this.state.removeRoles.length);
        let addedRoles = this.state.addedRoles.slice(0, this.state.addedRoles.length);
        let similar = false;
        

        for (let i = 0; i < addedRoles.length; i++) {
            if (addedRoles[i].Name == removeRole.Name) {
                similar = true;
                addedRoles.splice(i, 1);
            }
        }

        if (!similar) {
            removeRoles.push({ Name: removeRole.Name, Id: removeRole.Id });
        }

        

        this.setState({
            removeRoles: removeRoles,
            addedRoles: addedRoles
        });
    }

    changeRoles() {
        if (this.state.removeRoles.length != 0) {
        }

        if (this.state.addedRoles.length != 0) {
        }

        this.sendChangeRolesToServer();

        this.setState({
            addedRoles: [],
            removeRoles: []
        });
    }

    sendChangeRolesToServer() {
        let self = this;
        
        fetch(serverUrl + `api/User/${this.state.selectedUserId}`, {
            mode: 'cors',
            method: 'PUT',
            headers: {
                "Content-Type": "application/json"
            },
            body:
            JSON.stringify({
                DeleteRoles: this.state.removeRoles,
                AddRoles: this.state.addedRoles
            })
        }).then((response) => {
            console.log('OK');
        })
    }

    render() {
        return (
            <button className="save" onClick={this.changeRoles}>Save</button>
            )
    }
}