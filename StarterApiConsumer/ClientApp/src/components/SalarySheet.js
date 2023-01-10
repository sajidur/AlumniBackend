import React, { Component } from 'react';
import axios from 'axios';

export class SalaryShett extends Component {
    static displayName = SalaryShett.name;
    state = {
        selectedItem: 0,
        data: [],
        header: '',
        body:''
    }
    constructor(props) {
        super(props);
        this.state = {
            selectedItem: 0,
            data: [],
            header: '',
            body: ''
        };
        this.handleChange = this.handleChange.bind(this);
    }
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }
    generateHeader() {
        let header = Object.keys(this.state.data);
        console.log(header);

        return header.map((key, index) => {
            console.log(key+""+index);
            return <th key={index}>{key.toUpperCase()}</th>
        });
    }
    generateTableData() {
        let header = Object.keys(this.state.data);
        console.log(header);
        return header.map((key, index) => {
            console.log(key + "" + index);
            return <td key={index}>0</td>
        });
    }
    componentDidMount() {
        alert('Calling');
        fetch("https://localhost:44334/api/Salary/GetAll")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                var res=JSON.parse(data);
                this.setState({ data: res });
            }).catch(error => {
                console.log(error);
            });
    }
    render() {
        return (
            <div className='row'>
                <div className='col-md-4'>
                    <h4>Salary Sheet</h4>
                    <select name='ISValueConditions' onChange={this.handleChange}>
                        <option value='0'>--Select--</option>
                        <option value='1'>Bangladesh</option>
                        <option value='2'>USa</option>
                    </select>
                    <input className='btn btn-primary' type="button" value="Search" onClick={this.componentDidMount} />
                </div>
                <div className='col-md-8'>
                    <br />
                    <h4>Salary sheet</h4>
                    <table className="table  table-hover">
                        <thead>
                            <tr>
                                {this.generateHeader()}
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                {this.generateTableData()}
                            </tr>
                        </tbody>
                    </table>
                </div>
                
            </div>
        );
    }
}