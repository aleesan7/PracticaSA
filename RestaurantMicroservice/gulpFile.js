var gulp = require('gulp');
var uglify = require('gulp-uglify');
var zip = require('gulp-zip');

gulp.task('minify', function() {
  console.log('minifying js ...');
     return gulp.src('index.js')
    .pipe(uglify())
    .pipe(gulp.dest('build/js/'));
});

gulp.task('copy-packagejson', function() {
    console.log('moving package json file ...');
    return gulp.src('package.json')
      .pipe(gulp.dest('build/js/'))
    ;
  });

gulp.task('zip', function() {
    console.log('zipping files to export ...');
    return gulp.src('build/js/*')
      .pipe(zip('RestaurantMicroservice.zip'))
      .pipe(gulp.dest('dist'));
  });