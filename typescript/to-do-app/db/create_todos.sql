CREATE TABLE IF NOT EXISTS todos (
  id SERIAL PRIMARY KEY,
  description VARCHAR(255) NOT NULL,
  completed BOOLEAN DEFAULT FALSE
);