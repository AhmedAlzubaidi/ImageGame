import React, { Component } from 'react';
import { GameList } from '../components/GameList';

export class Home extends Component {
    static displayName = Home.name;

    render () {
        return (
            <div>
                <GameList />
            </div>
        );
    }
}