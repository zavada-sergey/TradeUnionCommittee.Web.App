from Controllers import app
from flask import Flask, request, jsonify, json
import Services.CheckingService as service

#------------------------------------------------------------------------------
# 5.1
# Return C#/.NET type => ''
#------------------------------------------------------------------------------
@app.route('/api/Checking/RelevanceWellnessTrips/Task1', methods=['POST'])
def checking_relevance_wellness_trips_task1():
    input_json = request.get_json(force=True)
    return service.checking_relevance_wellness_trips_task1(input_json)