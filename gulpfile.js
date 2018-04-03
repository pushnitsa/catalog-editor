'use strict';

var gulp = require('gulp'),
    rigger = require('gulp-rigger'),
    watch = require('gulp-watch'),
    notifier = require('node-notifier'),
    sourcemaps = require('gulp-sourcemaps'),
    uglify = require('gulp-uglify');

var path = {
    src: {
        js_main: 'Scripts/main.js',
        js_vendor: 'Scripts/vendor.js'
    },
    build: {
        basePath: 'wwwroot',
        js: 'js'
    }
};

function swallowError(error) {
    //If you want details of the error in the console
    console.log(error.toString());
    notifier.notify({
        'title': 'Gulp Error',
        'message': error.message
    });
    this.emit('end');
}

gulp.task('js:build', function () {
    gulp.src(path.src.js_main)
        .pipe(rigger())
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(sourcemaps.write())
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.js));
    gulp.src(path.src.js_vendor)
        .pipe(rigger())
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.js));
});

gulp.task('watch', function() {
    watch(path.src.js, function(event, cb) {
        gulp.start('js:build');
    });
});

gulp.task('default', ['js:build']);