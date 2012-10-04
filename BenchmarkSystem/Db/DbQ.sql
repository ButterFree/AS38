SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `benchmarksystem` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `benchmarksystem` ;

-- -----------------------------------------------------
-- Table `benchmarksystem`.`Owners`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `benchmarksystem`.`Owners` (
  `OwnerID` INT NOT NULL ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`OwnerID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benchmarksystem`.`Jobs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `benchmarksystem`.`Jobs` (
  `JobID` INT NOT NULL ,
  `CPU` TINYINT NOT NULL ,
  `ExpectedRuntime` INT NOT NULL ,
  `Owners_OwnerID` INT NOT NULL ,
  PRIMARY KEY (`JobID`) ,
  INDEX `fk_Jobs_Owners_idx` (`Owners_OwnerID` ASC) ,
  CONSTRAINT `fk_Jobs_Owners`
    FOREIGN KEY (`Owners_OwnerID` )
    REFERENCES `benchmarksystem`.`Owners` (`OwnerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benchmarksystem`.`JobState`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `benchmarksystem`.`JobState` (
  `JobStateID` INT NOT NULL ,
  `JobState` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`JobStateID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `benchmarksystem`.`Jobs_has_JobState`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `benchmarksystem`.`Jobs_has_JobState` (
  `Jobs_JobID` INT NOT NULL ,
  `JobState_JobStateID` INT NOT NULL ,
  `Timestamp` TIMESTAMP NOT NULL ,
  PRIMARY KEY (`Jobs_JobID`, `JobState_JobStateID`) ,
  INDEX `fk_Jobs_has_JobState_JobState1_idx` (`JobState_JobStateID` ASC) ,
  INDEX `fk_Jobs_has_JobState_Jobs1_idx` (`Jobs_JobID` ASC) ,
  CONSTRAINT `fk_Jobs_has_JobState_Jobs1`
    FOREIGN KEY (`Jobs_JobID` )
    REFERENCES `benchmarksystem`.`Jobs` (`JobID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Jobs_has_JobState_JobState1`
    FOREIGN KEY (`JobState_JobStateID` )
    REFERENCES `benchmarksystem`.`JobState` (`JobStateID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
