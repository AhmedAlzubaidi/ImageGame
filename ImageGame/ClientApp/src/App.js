import React, { Component } from 'react';
import { Route, Redirect } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './pages/index';
import { Play } from './pages/play';

import './custom.css'

/* <Route exact path='/' component={Home} />
<Route path='/counter' component={Counter} />
<Route path='/fetch-data' component={FetchData} /> */

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/'>
                    <Redirect to='/games' />
                </Route>
                <Route exact path='/games' component={Home} />
                <Route exact path='/games/:id/play' component={Play} />
            </Layout>
        );
    }
}
