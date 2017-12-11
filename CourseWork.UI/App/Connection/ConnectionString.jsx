import React from 'react';
import ReactDOM from 'react-dom';

const serverUrl = 'http://localhost:52367/';

class ConnectionString extends React.Component {
    constructor(props) {
        super();
        
        this.state = {
            connectstring: '',
            error: '',
            errorText: ''
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.buttonClick = this.buttonClick.bind(this);
    }

    handleInputChange(event) {
        this.setState({ connectString: event.target.value });
    }

    buttonClick() {
        let connectionString = ReactDOM.findDOMNode(this.refs.connectionString).value;

        fetch(serverUrl + 'api/ConnectionString', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },        
            body: JSON.stringify({
                "ConnectionString": connectionString
            }),
            mode: 'cors'
        })
            .then((response) => {
            window.ee.emit('UserConnected');
            }, 
                (error) => {
                console.log(error.message);
                });
            
    
        

    }

    render() {
        return (
            <div className='connection'>
                <input
                    className="connectionString"
                    id="connection"
                    value={this.state.connectString}
                    onChange={this.handleInputChange}
                    ref="connectionString"
                />
                <input
                    className="connectionButton"
                    onClick={this.buttonClick}                    
                    value='Connect'
                    type='button'
                />
            </div>
        );
    }
};

export default ConnectionString;