import React, { Component } from 'react';
import axios from 'axios';
import './rulesandcondition.css';

export class RulesAndCondition extends Component {
    static displayName = RulesAndCondition.name;
    state = {
        IsFixedFigure: true,
        IsRelatedTo: false,
        SalaryItems: [],
        conditions : [],
        selectedItem: 0,
        relatedSelectedItem: 0,
        RelatedPercentage: 0,
        Amount: 0,
        DeductionAmount: 0,
        AdditionAmount: 0,
        IFCondition: '',
        ISConditions: '',
        ISValueConditions: '',
        ConditionAmount:0
    }
    constructor(props) {
        super(props);
        this.state = {
            SalaryItems: [],
            selectedItem: '',
            relatedSelectedItem: "",
            IsFixedFigure: true,
            IsRelatedTo: false,
            conditions: [],
            RelatedPercentage: 0,
            Amount: 0,
            DeductionAmount: 0,
            AdditionAmount: 0,
            IFCondition: '',
            ISConditions: '',
            ISValueConditions: '',
            ConditionAmount: 0 };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }

    figureCalculationBasedOn = (event) => {
        if (event.target.value === 'relatedTo') {
            this.setState({ IsRelatedTo: true });
            this.setState({ IsFixedFigure: false });
        }
        if (event.target.value === 'fixedFigure') {
            this.setState({ IsRelatedTo: false });
            this.setState({ IsFixedFigure: true });
        }
        //if (event.target.value ==='percentage') {
        //    this.setState({ IsFixedFigure: true });
        //}
    }
    conditionsAdd = (event) => {
        var alreadyAdded = this.state.conditions;
        var condition = { IFCondition: this.state.IFCondition, ISConditions: this.state.ISConditions, ISValueConditions: this.state.ISValueConditions, Amount: this.state.Amount };
        alreadyAdded.push(condition);
        this.setState({ conditions: alreadyAdded });
        alert('Condition added');
    }
    componentDidMount() {
        fetch("https://localhost:44334/api/SalaryItem")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                let items = data.map(item => {
                    return { value: item.Id, display: item.Name }
                });
                this.setState({
                    SalaryItems: [{ value: '0', display: '--Select--' }].concat(items)
                });
            }).catch(error => {
                console.log(error);
            });
    }
    handleSubmit(event) {
        event.preventDefault();
        console.log(this.state);
        var request = { SalaryItemId: this.state.selectedItem, RelatedToItemId: this.state.relatedSelectedItem, Amount: this.state.Amount, IsFixedFigure: this.state.IsFixedFigure, IsRelatedTo: this.state.IsRelatedTo, AdditionAmount: this.state.AdditionAmount, DeductionAmount: this.state.DeductionAmount, RelatedPercentage: this.state.RelatedPercentage, conditions: this.state.conditions };
        axios.post('https://localhost:44334/api/Rules/Post', request)
            .then(res => {
                console.log(res);
                console.log(res.data);
                if (res.data) {
                    alert('Data saved');
                }
                else {
                    alert('Faled');
                }
            });
    }

    render() {
        return (
            <div>
                <div className='row'>
                    <div className='col-md-6'>
                        <h4>Add Rules</h4>
                        <form onSubmit={this.handleSubmit}>
                            <div className='row'>
                                <div className='col-md-4'>Benifit</div>
                                <div className='col-md-4'>
                                    <select value={this.state.selectedItem}
                                        onChange={(e) => this.setState({ selectedItem: e.target.value })}>
                                        {this.state.SalaryItems.map((item) => <option key={item.value} value={item.value}>{item.display}</option>)}
                                    </select>
                                </div>
                                <div className='col-md-4'>Will be </div>
                            </div>
                            <div className='row'>
                                <div className='col-md-4'>
                                    <input type="radio" id="fixedFigure" name="fixed" value="fixedFigure" onClick={this.figureCalculationBasedOn} />
                                    <label for="fixedFigure">Fixed Figure</label>
                                 </div>
                                <div className='col-md-4'>
                                    <input name="Amount" value={this.state.value} type="number" onChange={this.handleChange} />
                                </div>
                            </div>
                            <div className='row'>
                                <div className='col-md-4'>
                                    <input type="radio" id="relatedTo" name="fixed" value="relatedTo" onClick={this.figureCalculationBasedOn} />
                                    <label for="relatedTo">Related To Benifit</label>
                                </div>
                                <div className='col-md-4'>
                                    <select value={this.state.relatedSelectedItem}
                                        onChange={(e) => this.setState({ relatedSelectedItem: e.target.value })}>
                                        {this.state.SalaryItems.map((item) => <option key={item.value} value={item.value}>{item.display}</option>)}
                                    </select>
                                </div>
                            </div>
                            <div className='row'>
                                <div className='col-md-4'>
                                </div>
                                <div className='col-md-4'>
                                    <input type="radio" id="percentage" name="OtherBenifit" value="percentage" onClick={this.figureCalculationBasedOn} />
                                    <label for="percentage">In (%)</label>
                                </div>
                                <div className='col-md-4'>
                                    <input name="RelatedPercentage" value={this.state.value} type="number" onChange={this.handleChange} />
                                </div>
                            </div>
                            <div className='row'>
                                <div className='col-md-4'>
                                </div>
                                <div className='col-md-4'>
                                    <input type="radio" id="Increment" name="OtherBenifit" value="Increment"  />
                                    <label for="Increment">Increment</label>
                                </div>
                                <div className='col-md-4'>
                                    <input name="AdditionAmount" width='20px;' value={this.state.value} type="number" onChange={this.handleChange} />
                                </div>
                            </div>
                            <div className='row'>
                                <div className='col-md-4'>
                                </div>
                                <div className='col-md-4'>
                                    <input type="radio" id="Decrement" name="OtherBenifit" value="Decrement" />
                                    <label for="Decrement">Decrement</label>
                                </div>
                                <div className='col-md-4'>
                                    <input name="DeductionAmount" value={this.state.value} type="number" onChange={this.handleChange} />
                                </div>
                            </div>                             
                            <input className='btn btn-primary' type="submit" value="Submit" />
                        </form>
                    </div>
                    <div className='col-md-2'>
                    </div>
                    <div className='col-md-4'>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td> <h4> Conditions</h4>
                                </td>
                                <td>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <input type="radio" id="Decrement" name="Condition" value="Decrement" />
                                    <label for="Decrement">If</label>
                                </td>
                                <td>
                                    <select name='IFCondition' onChange={this.handleChange}>
                                        <option value='0'>--Select--</option>
                                        <option value='Male'>Male</option>
                                        <option value='Female'>Female</option>
                                    </select>
                                </td>
                                <td>
                                    <select name='ISConditions' onChange={this.handleChange}>
                                        <option value='0'>--Select--</option>
                                        <option value='equal'>is equal</option>
                                        <option value='or'>or</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <input type="radio" id="Decrement" name="Condition" value="Decrement" />
                                    <label for="Decrement"></label>
                                </td>
                                <td>
                                    <select name='ISValueConditions' onChange={this.handleChange}>
                                        <option value='0'>--Select--</option>
                                        <option value='Pregnent'>Pregnent</option>
                                        <option value='Dead'>Dead</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <input type="radio" id="Decrement" name="Condition" value="Decrement" />
                                    <label for="Decrement"></label>
                                </td>
                                <td>
                                    <input name="ConditionAmount" value={this.state.value} type="number" onChange={this.handleChange} />
                                </td>
                            </tr>
                        </table>
                        <div>
                            <input className='btn btn-primary' type="button" value="Add" onClick={this.conditionsAdd} />
                        </div>
                    </div>
                </div>

            </div>
        );
    }
}