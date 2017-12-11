import React from 'react';
import ListOfRoles from './ListOfRoles/ListOfRoles';
import ListOfUsers from './ListOfUsers/ListOfUsers';
import UserRoles from './ListOfRoles/UserRoles';
import SaveChange from '../SaveChange/SaveChange';

window.ee = new EventEmitter();
const serverUrl = 'http://localhost:52367/';

class ListOfUsersAndRoles extends React.Component{
    constructor() {
        super();

        this.state = {
            users: [],
            roles: [],
            isConnected: false
        };
        this.getRolesFromServer = this.getRolesFromServer.bind(this);
        this.getUsersFromServer = this.getUsersFromServer.bind(this);
    }


    componentDidMount() {
        let self = this;

        window.ee.addListener('UsersList.add', (loadUsers) => {
            self.setState({
                users: loadUsers
            });
        });

        window.ee.addListener('RolesList.add', (loadRoles) => {
            self.setState({
                roles: loadRoles
            });
        });

        
        window.ee.addListener('UserConnected', () => {
            self.setState({
                isConnected: true
            });
            this.getUsersFromServer();
            this.getRolesFromServer();
        });

    }

    getUsersFromServer() {
        let self = this;

        fetch(serverUrl + 'api/User', {
            mode: 'cors',
            method:'GET',
            headers:{
                "Content-Type": "application/json"
            }
        })
        .then((resp) => resp.json())
        .then(function(data) {
            let users = [];
            let roles = [];

            data.map(function (user) {

                roles = user.ActiveRoles;
                
                users.push({
                    Name: user.Fullname,
                    id: user.Id,
                    role: user.ActiveRoles
                })
            })

            self.setState({
                isConnected: true,
                users: users,
            });
        }, (error) => {
            console.log(error.message);
        })
    }

    getRolesFromServer(){
        let self = this;

        fetch(serverUrl + 'api/Role', {
            mode: 'cors',
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then((resp) => resp.json())
        .then(function (data) {
            let roles = [];

            data.map(function (role) {
                roles.push({ role: role.Name, id: role.Id })
            })

            self.setState({
                isConnected: true,
                roles: roles,
            });
        }, (error) => {
            console.log(error.message);
        })
    }

    componentWillUnmount() {
        window.ee.removeListener('UsersList.add');
        window.ee.removeListener('RolesList.add');
        window.ee.removeListener('UserConnected');
    }

    render() {
        if (!this.state.isConnected) {
            return (<div className="data">Haven't data.</div>);
        }

        const users = this.state.users.slice(0, this.state.users.length);
        const roles = this.state.roles.slice(0, this.state.roles.length);

        return (
            <div>
                <div className='listofusersandroles'>
                    <ListOfUsers data={users} /> 
                    <ListOfRoles data={roles} users={users} />
                    <UserRoles data={users} />
                </div>
                <div>
                    <SaveChange />
                </div>
            </div>
        );
    }
}

export default ListOfUsersAndRoles;