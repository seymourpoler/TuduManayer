package net.seymourpoler.tudumanager.web.api.spring.boot;

import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpStatus;

import static org.assertj.core.api.Assertions.assertThat;

public class PingControllerShould {
    PingController controller;

    @Before
    public void setUp(){
        controller  = new PingController();
    }

    @Test
    public void return_pong(){
        var response = controller.ping();

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.OK);
        assertThat(response.getBody()).isEqualTo("PONG");
    }
}
