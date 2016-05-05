$(function() {

	var queueId;
	var queueUrl;
	var sqs;

	$('.btnSend').on('click',function(){
		var alt = $(this).attr('alt');
		if(!alt){
			return false;
		}

		var queueIdTemp = $('#queueId').val().replace(' ','');
		if(queueIdTemp == queueId){
			sendMessage($(this).attr('alt'));
		}else{
			queueId = queueIdTemp;
			updateQueueUrl($(this).attr('alt'));
		}
		return false;
	});

	var updateQueueUrl = function(messageBody) {
		$.ajax({
			type: "GET",
			url: "https://x5pdzbgoo6.execute-api.ap-northeast-1.amazonaws.com/prod/imGetQueueUrl?queueId=" + queueId
		}).done(function(data){
			console.log(data);
			queueUrl = data.QueueUrl;
			sqs = new AWS.SQS({
				region:'ap-northeast-1',
				accessKeyId:data.AccessKeyId,
				secretAccessKey:data.SecretAccessKey,
				sessionToken:data.SessionToken
			});
			sendMessage(messageBody);
		});
	};

	var sendMessage = function(messageBody) {
		var params = {
			MessageBody: messageBody,
			QueueUrl: queueUrl
		};
		sqs.sendMessage(params, function(err, data) {
			if (err) {
				console.log(err);
			} else {
				console.log(data);
			}
		});
	};

	var initBtn = function() {
	};
});
