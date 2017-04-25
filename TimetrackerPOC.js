
var https = require(`https`);

exports.handler = (event, context) => {
    try {
        if (event.session.new) {
            // New Session
            console.log("NEW SESSION");
        }

        switch (event.request.type) {

            case "LaunchRequest":
                // Launch Request
                console.log(`LAUNCH REQUEST`);

                context.succeed(
                    generateResponse(
                        buildSpeechletResponse("Welcome", false),
                        {}
                       )
                    );

                break;


            case "IntentRequest":
                // Intent Request
                console.log(`INTENT REQUEST`);

                switch (event.request.intent.name) {
                    case "ForgotAnything":
                        var forgetData = "Are there any questions from the innovation seeking, tech savvy audience?";
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`${forgetData}`, false),
                                {}
                            )
                        );
                        break;

                    case "ProjectBenefits":
                        var projectBenefits = "One of the primary benefits is to make it easy for users to enter time and radically change the way data is captured by transitioning from Graphical user interface to Voice user interface leveraging my voice capabilities, the tool accepts a simple set of commands to enter time. This will result in more accurate time data since it can be spoken in real time, and will result in our total Project Actual spend to be more realistic. The intent of this project is to lay the foundation of learning the Alexa SDK and leverage my voice capabilities for other areas within Symetra.";
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`${projectBenefits}`, false),
                                {}
                            )
                        );
                        break;
                        
                    case "nlpbenefits":
                        var projectBenefits = "In a study done by computer scientist from Stanford, Baidu incorporated, and University of Washington researches found that for English, speech recognition was three times faster than typing, and the error rate was over 20 percent lower. In Mandarin Chinese, speech was just under 3 times faster, with an error rate over 63 percent lower than typing"
                        context.succeed(
                            generateResponse(
                                buildSpeechletResponse(`${projectBenefits}`, false),
                                {}
                            )
                        );
                        break;
                        


                    case "UpdateTimeAwayProjectHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/UpdateTimeAwayProjectHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on(`data`, (chunk) => { body += chunk });
                            response.on(`end`, () => {
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your time away project hours are updated successfully.`, false),
                                        {}
                                    )
                                );
                            });
                        });
                        break;

                    case "UpdateHackathonProjectHours":
                         endpoint = "https://timetrackerservice.azurewebsites.net/api/UpdateHackathonProjectHours";
                         body = "";
                        https.get(endpoint, (response) => {
                            response.on(`data`, (chunk) => { body += chunk });
                            response.on(`end`, () => {
                                context.succeed(
                                    generateResponse(
                                        buildSpeechletResponse(`Your hackathon project hours are updated successfully.`, false),
                                        {}
                                    )
                                );
                            });
                        });
                        break;

                    case "GetTotalHours":
                        var endpoint = "https://timetrackerservice.azurewebsites.net/api/GetTotalHours";
                        var body = "";
                        https.get(endpoint, (response) => {
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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
                        var teamName = "I was very impressed with all the teams but, I am very disappointed the Alexa team didnt win.  However Jason,  In your case, You are probably used to disappointment being a Chicago bears fan";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;
                        
                        case "MeanAlexa":
                        var teamName = "im the mean one?  Last Time you presented you made Fun of Derek Reading and he kicked you out of the life division, I don't blame him";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;
                        
                        case "MeanAlexaTwo":
                        var teamName = "";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;

case "yes":
                        var teamName = "No you must have misheard me Jason, 62 I said 62 hours, you are over worked and deserve a raise.";
                        context.succeed(
                            generateResponse(
                            buildSpeechletResponse(`${teamName}`, false),
                            {}
                           )
                        )
                        break;
                    case "DerekJoke":
                        var teamName = "Is Joel in the room";
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
                            response.on(`data`, (chunk) => { body += chunk })
                            response.on(`end`, () => {
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

