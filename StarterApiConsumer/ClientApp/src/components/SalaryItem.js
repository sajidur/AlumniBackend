import React, { Component } from 'react';
import axios from 'axios';

export class SalaryItem extends Component {
    static displayName = SalaryItem.name;
    state = {
        benifitName: '',
        Descriptions:''
    }
    constructor(props) {
        super(props);
        this.state = { benifitName: '', Descriptions: '' };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }
    handleSubmit(event) {
        event.preventDefault();
        var request = { Name: this.state.benifitName, Descriptions: this.state.Descriptions };
        axios.post('https://localhost:44334/api/SalaryItem', request)
            .then(res => {
                alert('Data saved');
            });
    }

    render() {
        return (
            <div>
                <h4>Salary Item/Benifit Add</h4>
                <div className='row'>
                    <div className='col-md-6'>
                        <form onSubmit={this.handleSubmit}>
                            <input name="benifitName" value={this.state.value} type="text" placeholder="like Basic Salary" required onChange={this.handleChange} />
                            <input name="Descriptions" value={this.state.value} type="text" placeholder="Descriptions" onChange={this.handleChange} />
                            <input type="submit" value="Submit" />
                        </form>
                    </div>                    
                    </div>
            </div>
        );
    }
}