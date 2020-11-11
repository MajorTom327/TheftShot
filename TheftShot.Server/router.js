const multer = require('multer');
const fs = require('fs');
const path = require('path');
const express = require('express');
const db = require('./database');
const R = require('ramda');

const upload = multer({ dest: 'uploads/' });
const uploadPath = path.join(__dirname, 'uploads');

module.exports = (app) => {

    // * Add files
    app.post('/files', upload.single('file'), (req, res) => {
        const { file } = req;
        console.log(file);
        fs.renameSync(
            path.join(file.destination, file.filename),
            path.join(file.destination, file.originalname)
        );


        res.json({}).end()
    });

    app.get('/files', (req, res) => {
        const ret = fs.readdirSync(uploadPath);

        console.log(ret);
        res.json(ret).end();
    })

    app.use('/files', express.static(uploadPath));

    app.post('/log', (req, res) => {
        console.log(req.body);
        const event = R.pick(['type', 'date'], req.body);

        db.get('events')
            .push(event)
            .write()

        res.json(event).end();
    });
    app.get('/log', (req, res) => {
        const events = db.get('events').value();
        res.json(events).end();
    })
}