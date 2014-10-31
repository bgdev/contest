#!/usr/bin/env phantomjs

args = require('system').args
page = require('webpage').create()


if args.length < 3
  console.log "usage: #{args[0]} <url> <solution-file>"
  phantom.exit 1


# URL = 'https://code.google.com/codejam/contest/32003/dashboard'
# FP = '/home/y/prg/bgdev/contest/qwe'
URL = args[1]
FP = args[2]


time = -> new Date().getTime()


# Wait for condfn() to return true, then execute ready()
waitfor = (condfn, ready, timeout = 3000) ->
  start = time()
  interval = setInterval(
    ->
      if condfn()
        clearInterval interval
        ready()
      else if time() - start > timeout
        phantom.exit 1
    300
  )


# Execute callback `cb` once fn() returns a different output
onchange = (fn, cb, interval = 100) ->
  initial = fn()
  handle = setInterval(
    ->
      current = fn()
      if current != initial
        clearInterval handle
        cb current
    interval
  )


# Capture and return the current page message
message = ->
  page.evaluate ->
    html = document.getElementById('dsb-status-msg-text').innerHTML
    html.replace /<[^>]+>/g, ''


# True if message says solution is correct, false otherwise
is_correct = -> message().indexOf('Correct!') != -1


page.open URL, (status) ->
  phantom.exit(1) if status != 'success'

  # Wait for the page to load up completely (it does so by AJAX).  We
  # try clicking the Solve button to show up the submit form.  Once the
  # form is visible, we use it to upload the solution file.
  waitfor(
    ->
      page.evaluate ->
        document.getElementById('dsb-input-start-button0-0')?.click()
        div = document.getElementById 'dsb-submit-form-div0-0'
        if div? then div.style.display != 'none' else false
    ->
      # Before uploading the solution file, we first register for
      # changes in the message area.  That's how we can tell if the
      # solution is being evaluated as correct or not.
      onchange message, (m) ->
        console.log m
        code = if is_correct(m) then 0 else 1
        phantom.exit code

      # Upload the solution file
      page.uploadFile '#output-fileio_timer_0', FP
      page.evaluate ->
        document.getElementById('submit-buttonio_timer_0').click()
  )
