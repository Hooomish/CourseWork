import React from 'react';

class UserRoles extends React.Component {
    constructor(props) {
        super(props);
        

        this.state = {
            users: this.props.data,
            selectUser: "",
            removeRoles: [],
            addedRoles: []
        };

        this.delete = this.delete.bind(this);
        this.eventAddedRoles = this.eventAddedRoles.bind(this);
    }

    componentDidMount() {
        let self = this;        

        window.ee.addListener('userRoles', (loadUser) => {
            self.setState({
                selectUser: loadUser
            });
        });
    }

    

    componentWillUnmount() {
        window.ee.removeListener('userRoles');
        window.ee.removeListener('removeRoles');
        window.ee.removeListener('addedRoles');
    }

    delete(i, j){
        let changedUser = this.props.data.slice(0, this.props.data.length);

        window.ee.emit('removeRoles', { Name: changedUser[i].role[j].Name, Id: changedUser[i].role[j].Id });
        
        changedUser[i].role.splice(j, 1);

        
        
        this.setState({
            users: changedUser
        });
        
        window.ee.emit('SelectedUser', this.state.selectUser);
    }

    eventAddedRoles(i, j) {
        let Name = this.props.data[i].role[j].Name;
        
                this.state.addedRoles.push({
                    Name: this.props.data[i].role[j].Name,
                    Id: this.props.data[i].role[i].Id
                });

        for (let k = 0; k < this.state.removeRoles.length; i++) {
            if (this.state.removeRoles[k].Name == Name) {
                this.state.removeRoles.splice(k, 1);
            }
        }

    }

    render() {
        const users = this.props.data;
        var selectUser = this.state.selectUser;
        var Roles = [];

        for (let i = 0; i < users.length; i++) {
            if (users[i].Name == selectUser) {
                for (let j = 0; j < users[i].role.length; j++) {

                    Roles.push(
                        <div key={i + 1 + `${j}`} className="userRole">
                            {users[i].role[j].Name}                            
                        
                            <button className="button" type="button" onClick={() => this.delete(i, `${j}`)} >
                                -
                            </button>
                        </div>
                    );
                }
            }
        }

        return (
            <div className='userRoles'>
                {Roles.length > 0 ? Roles : ' '}
            </div>
            )
    }
}

export default UserRoles;