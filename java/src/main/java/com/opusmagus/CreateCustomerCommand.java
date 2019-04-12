package com.opusmagus;

import org.apache.commons.logging.Log;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CreateCustomerCommand implements ICommand {
    @Autowired
	private Log logger;
	
	public CreateCustomerCommand() {
	}

	@Override
	public void Execute() {		
		logger.info("Executing command CreateCustomerCommand...");
	}
}