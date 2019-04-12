package com.opusmagus;

import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.experimental.categories.Category;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringRunner;

@RunWith(SpringRunner.class)
@ContextConfiguration(classes = {AppConfig.class})
public class CreateCustomerCommandTest {

	@Autowired private CreateCustomerCommand command;
	@Test
	@Category(UnitTest.class)
	public void Execute() {
		command.Execute();
		assertEquals(1, 1);
	}
}
