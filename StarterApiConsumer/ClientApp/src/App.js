import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { SalaryItem } from './components/SalaryItem';

import './custom.css'
import { RulesAndCondition } from './components/RulesAndCondition';
import { SalaryShett } from './components/SalarySheet';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/rules--and-condition' component={RulesAndCondition} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/SalaryItem' component={SalaryItem} />
            <Route path='/salary-sheet' component={SalaryShett} />

      </Layout>
    );
  }
}
