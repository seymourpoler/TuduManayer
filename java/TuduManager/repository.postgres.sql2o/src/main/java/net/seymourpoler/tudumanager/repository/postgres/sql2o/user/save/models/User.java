package net.seymourpoler.tudumanager.repository.postgres.sql2o.user.save.models;

import java.time.LocalDateTime;

public class User {
        public String email;
        public String password;
        public LocalDateTime creation_date;
        public LocalDateTime updated_date;
}
