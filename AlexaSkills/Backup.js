
var https = require('https')

exports.handler = (event, context) => {
    try {
        if (event.session.new) {
            // New Session 
            console.log("NEW SESSION")
        }

        switch (event.request.type) {

            case "LaunchRequest":
                // Launch Request 
                console.log(`LAUNCH REQUEST`)

                context.succeed(
                    generateResponse(
                        buildSpeechletResponse("Welcome", false),
                        {}
                       )
                    )

                break;


            case "IntentRequest":
                // Intent Request 
                console.log(`INTENT REQUEST`)

                switch (event.request.intent.name) {
                    case "ForgotAnything":
                        var forgetData = "Are there any questions from the innovation seeking, tech savvy audience?"
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`${forgetData}`, false),
                                {}
                            )
                        )
                        break;

                    case "ProjectBenefits":
                        var projectBenefits = "One of the primary benefits is to make it easy for users to enter time and radically change the way data is captured. By leveraging my voice capabilities, the tool accepts a simple set of commands to enter time. This will result in more accurate time data since it can be spoken in real time, and will result in our total Project Actual spend to be more realistic. The intent of this project is to lay the foundation of learning the Alexa SDK and leverage my voice capabilities for other areas within Symetra."
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`${projectBenefits}`, false),
                                {}
                            )
                        )
                        break;

                    case "UpdateTimeAwayProjectHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/UpdateTimeAwayProjectHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your time away project hours are updated successfully.`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "UpdateHackathonProjectHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/UpdateHackathonProjectHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your hackathon project hours are updated successfully.`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "GetTotalHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/GetTotalHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                var data = JSON.parse(body)
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`total hours are ${data}`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "GetActivitySummary":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/GetActivitySummary";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                var data = JSON.parse(body)
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your summary is ${data}`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "GetUsersFullName":
                        var WelcomeMessage = "The Team members are as follows, ";
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/ttwebapi/GetUsersFullName";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                var data = JSON.parse(body)
                                var IntroData = WelcomeMessage + data
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`${IntroData}`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "UpdateProjectHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/UpdateProjectHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your hours are updated successfully.`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;

                    case "PASRPolicyPlans":
                        var endpoint = "https://pasrpocservices.azurewebsites.net/PolicyPlans?"
                        var body = ""
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                var data = JSON.parse(body)
                                var viewCount = data.value[0].PolicyholderName + " "
                                viewCount += data.value[1].PolicyholderName
                                viewCount = data.value.length
                                context.succeed(
                                    generateResponse(
                                    buildSpeechletResponse(`new Payser policy plan count is  ${viewCount}`, false),
                                     {}
                                   )
                                )
                            })
                        })
                        break;

                    case "ProjectIntro":
                        var teamName = "The project uses me, Alexa, to allow time tracker entry via voice command. The team combined two ideas which were to improve time tracking and to utilize me as a voice enabled customer service tool.";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;

                    case "CarrozJoke":
                        var teamName = "Well, I would really like to see the alexa team win, but everyone knows that Carroz wins everything";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;

                    case "DerekJoke":
                        var teamName = "Hold on, hold on Jason, that is still more than Derek Reading worked last month.";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;

                    case "GetProjectTime":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/getprojecttime/getprojecttime";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on('data', (chunk) => { body += chunk })
                            response.on('end', () => {
                                var data = JSON.parse(body)
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`${data} hours`, false),
                                        {}
                                    )
                                )
                            })
                        })
                        break;
                    case "ByeAlexa":
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`Bye...`, true),
                                {}
                            )
                        )
                        break;

                    default:
                        throw "Invalid intent";
                }
                break;


            case "SessionEndedRequest":
                // Session Ended Request 
                console.log(`SESSION ENDED REQUEST`)
                context.succeed(
                    generateResponse(
                        buildSpeechletResponse(`Bye Everyone`, true),
                        {}
                    )
                )
                break;


            default:
                context.fail(`INVALID REQUEST TYPE: ${event.request.type}`)

        }

    } catch (error) { context.fail(`Exception: ${error}`) }
}


// Helpers 
buildSpeechletResponse = (outputText, shouldEndSession) => {
    return {
        outputSpeech: {
            type: "PlainText",
            text: outputText
        },
        shouldEndSession: shouldEndSession
    }


}


generateResponse = (speechletResponse, sessionAttributes) => {


    return {
        version: "1.0",
        sessionAttributes: sessionAttributes,
        response: speechletResponse
    }


}