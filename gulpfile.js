'use strict';

var gulp = require('gulp'),
    rigger = require('gulp-rigger'),
    watch = require('gulp-watch'),
    notifier = require('node-notifier'),
    sourcemaps = require('gulp-sourcemaps'),
    uglify = require('gulp-uglify'),
    cleancss = require('gulp-clean-css'),
    sass = require('gulp-sass');

var path = {
    src: {
        js: {
            main: 'Scripts/main.js',
            vendor: 'Scripts/vendor.js'
        },
        css: {
            main: 'Styles/main.scss',
            vendor: 'Styles/vendor.scss'
        }
    },
    build: {
        basePath: 'wwwroot',
        js: 'js',
        css: 'css'
    },
    watch: {
        css: 'Styles/**/*',
        js: 'Scripts/**/*'
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
    gulp.src(path.src.js.main)
        .pipe(rigger())
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(sourcemaps.write())
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.js));
    gulp.src(path.src.js.vendor)
        .pipe(rigger())
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.js));
});

gulp.task('css:build', function () {
    gulp.src(path.src.css.main)
        .pipe(sass())
        .pipe(sourcemaps.init())
        .pipe(cleancss({rebase: false}))
        .pipe(sourcemaps.write())
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.css));
    gulp.src(path.src.css.vendor)
        .pipe(sass())
        .pipe(cleancss({rebase: false}))
        .on('error', swallowError)
        .pipe(gulp.dest(path.build.basePath + '/' + path.build.css));
});

gulp.task('watch', function() {
    watch(path.watch.js, function(event, cb) {
        gulp.start('js:build');
    });
    watch(path.watch.css, function(event, cb) {
        gulp.start('css:build');
    });
});

gulp.task('default', ['js:build', 'css:build']);