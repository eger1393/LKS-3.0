import React from 'react';
import { Route } from 'react-router';
import Test from '../components/_common/elements/studentList'

export default () => (
        <Route exact path='/' component={Test} />
);
