'use strict';
const express = require('express');
const R = require('ramda');

const app = express();

app.use(require('cookie-parser')());
app.use(require('body-parser').urlencoded({ extended: true }));
app.use(require('body-parser').json({}));
app.use(require('compression')());

// Todo: Set router

require('./router')(app);


const port = R.pathOr(1337, ['env', 'port'], process);
app.listen(port, () => {
    console.log(`Server started on port ${port}`);
})
