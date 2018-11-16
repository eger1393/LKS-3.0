import React from 'react';
import { Route } from 'react-router';
import Test from '../components/pages/StudentList'

export default () => (
        <Route exact path='/' component={Test} />
);
