var ids = ["ChIJhUqKfnhMHRURu3eCgSrVQ0g", "ChIJMSvYp3hMHRUR8fpSwMPLcoA", "ChIJFQRqB3hMHRUR-1tOXl7RuFY", "ChIJuT8zHIhLHRURXA8MF5eiy08",
    "ChIJVwnIgXhMHRUR47JmW3COzec", "ChIJD0PgfnhMHRUR9yTs4Vo6i3M", "ChIJHTkinnhMHRURNYfDd-ZENk4", "ChIJZwhojoBLHRURERdYZvkE9-w", "ChIJ2bY7OXxLHRURzX8mGhCwRG8",
    "ChIJcTB10_JLHRURQghn5G-3QAY", "ChIJaUBwcIRLHRURNeakxb3j4MI", "ChIJ2fUlhYVLHRUR33u7or8YoTQ", "ChIJ3V_U_4FLHRURixff63jDUfw", "ChIJefEeWH1LHRURMLzgs_EVMgY",
    "ChIJDQA3EX1LHRURbVnMqnXQS3Y", "ChIJBSRvI51MHRUROnMh2Iq-ONw", "ChIJ4UdtSZ1MHRURCuAvEzrpi7Q", "ChIJGZ9jZSjWAhURELVlLJh_jxw", "ChIJ6weP6yjWAhURgBKviLD8Kh8",
    "ChIJ5UpFfCjWAhURO2i7e9IeIhE", "ChIJC9QmWyjWAhUR33Z6a30Jh8g", "ChIJZxCKkijWAhUR-o1nga9-4iM", "ChIJAXiWutEpAxURQsPfOH8X_J4", "ChIJcRbkxtApAxUR8AcnCySqpGg",
    "ChIJHdRoPtEpAxURbR1hoAFqREk", "ChIJzRINidYpAxUR4aSpuY7Svy8", "ChIJzaPwbdEpAxURY-_GIRkgFzc", "ChIJ1Qje4f5JHRURaFFjNKBPEts", "ChIJ75yU16dqHRUR175YJ_om7gc"];

function myFunc(id) {
    var loc = "BarRating.aspx?barId=" + ids[id-1];
    location.href = loc;
}


$(document).ready(function () {
    $('.collapsible').collapsible();
});

