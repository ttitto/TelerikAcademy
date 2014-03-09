SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `Universities` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `Universities` ;

-- -----------------------------------------------------
-- Table `mydb`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Faculties` (
  `FacultieId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`FacultieId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Departments` (
  `DepartmentId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `Faculties_FacultieId` INT NOT NULL,
  PRIMARY KEY (`DepartmentId`),
  INDEX `fk_Departments_Faculties_idx` (`Faculties_FacultieId` ASC),
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`Faculties_FacultieId`)
    REFERENCES `mydb`.`Faculties` (`FacultieId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Professors` (
  `ProfessorId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `CourseId` INT NULL,
  `Departments_DepartmentId` INT NOT NULL,
  PRIMARY KEY (`ProfessorId`),
  INDEX `fk_Professors_Departments1_idx` (`Departments_DepartmentId` ASC),
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_DepartmentId`)
    REFERENCES `mydb`.`Departments` (`DepartmentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Courses` (
  `CourseId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `Departments_DepartmentId` INT NOT NULL,
  PRIMARY KEY (`CourseId`),
  INDEX `fk_Courses_Departments1_idx` (`Departments_DepartmentId` ASC),
  CONSTRAINT `fk_Courses_Departments1`
    FOREIGN KEY (`Departments_DepartmentId`)
    REFERENCES `mydb`.`Departments` (`DepartmentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Titles` (
  `TitleId` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NULL,
  PRIMARY KEY (`TitleId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Professors_has_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Professors_has_Titles` (
  `Professors_ProfessorId` INT NOT NULL,
  `Titles_TitleId` INT NOT NULL,
  PRIMARY KEY (`Professors_ProfessorId`, `Titles_TitleId`),
  INDEX `fk_Professors_has_Titles_Titles1_idx` (`Titles_TitleId` ASC),
  INDEX `fk_Professors_has_Titles_Professors1_idx` (`Professors_ProfessorId` ASC),
  CONSTRAINT `fk_Professors_has_Titles_Professors1`
    FOREIGN KEY (`Professors_ProfessorId`)
    REFERENCES `mydb`.`Professors` (`ProfessorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_has_Titles_Titles1`
    FOREIGN KEY (`Titles_TitleId`)
    REFERENCES `mydb`.`Titles` (`TitleId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses_has_Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Courses_has_Professors` (
  `Courses_CourseId` INT NOT NULL,
  `Professors_ProfessorId` INT NOT NULL,
  PRIMARY KEY (`Courses_CourseId`, `Professors_ProfessorId`),
  INDEX `fk_Courses_has_Professors_Professors1_idx` (`Professors_ProfessorId` ASC),
  INDEX `fk_Courses_has_Professors_Courses1_idx` (`Courses_CourseId` ASC),
  CONSTRAINT `fk_Courses_has_Professors_Courses1`
    FOREIGN KEY (`Courses_CourseId`)
    REFERENCES `mydb`.`Courses` (`CourseId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_has_Professors_Professors1`
    FOREIGN KEY (`Professors_ProfessorId`)
    REFERENCES `mydb`.`Professors` (`ProfessorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Students` (
  `StudentId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  `Faculties_FacultieId` INT NOT NULL,
  PRIMARY KEY (`StudentId`),
  INDEX `fk_Students_Faculties1_idx` (`Faculties_FacultieId` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_FacultieId`)
    REFERENCES `mydb`.`Faculties` (`FacultieId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Courses_has_Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Universities`.`Courses_has_Students` (
  `Courses_CourseId` INT NOT NULL,
  `Students_StudentId` INT NOT NULL,
  PRIMARY KEY (`Courses_CourseId`, `Students_StudentId`),
  INDEX `fk_Courses_has_Students_Students1_idx` (`Students_StudentId` ASC),
  INDEX `fk_Courses_has_Students_Courses1_idx` (`Courses_CourseId` ASC),
  CONSTRAINT `fk_Courses_has_Students_Courses1`
    FOREIGN KEY (`Courses_CourseId`)
    REFERENCES `mydb`.`Courses` (`CourseId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_has_Students_Students1`
    FOREIGN KEY (`Students_StudentId`)
    REFERENCES `mydb`.`Students` (`StudentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
