import React from 'react';
import Connection from './Connection/Connection';
import ListOfUsersAndRoles from './ListOfUsersAndRoles/ListOfUsersAndRoles';


window.ee = new EventEmitter();

class App extends React.Component{
    render() {
        return (
            <div className='app'>
                <Connection />
                <ListOfUsersAndRoles />
            </div>
        );
    }
};

export default App;