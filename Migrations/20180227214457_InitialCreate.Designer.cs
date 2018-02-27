﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PDFOnlineSignature.Models;
using System;

namespace PDFOnlineSignature.Migrations
{
    [DbContext(typeof(PDFOnlineSignatureContext))]
    [Migration("20180227214457_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("PDFOnlineSignature.Models.Certificate", b =>
                {
                    b.Property<string>("Uuid");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("date");

                    b.Property<string>("ReviewerUuid");

                    b.Property<DateTime?>("RevokeDate");

                    b.Property<bool?>("Revoked");

                    b.Property<string>("SerialNumber")
                        .IsRequired();

                    b.HasKey("Uuid");

                    b.HasIndex("ReviewerUuid")
                        .IsUnique();

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.CertificateRequest", b =>
                {
                    b.Property<string>("Uuid");

                    b.Property<string>("CertificateUuid");

                    b.Property<DateTime?>("RequestDate")
                        .HasColumnType("date");

                    b.Property<string>("ReviewerUuid")
                        .IsRequired();

                    b.Property<string>("SecurityCode")
                        .IsRequired();

                    b.HasKey("Uuid");

                    b.HasIndex("CertificateUuid");

                    b.HasIndex("ReviewerUuid");

                    b.ToTable("CertificateRequest");
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.Document", b =>
                {
                    b.Property<string>("Uuid");

                    b.Property<DateTime>("CreationdDate");

                    b.Property<string>("MimeType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ReviewerUuid");

                    b.Property<DateTime?>("SignatureDate");

                    b.Property<bool?>("Signed");

                    b.Property<long>("Size");

                    b.HasKey("Uuid");

                    b.HasIndex("ReviewerUuid");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.Reviewer", b =>
                {
                    b.Property<string>("Uuid");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Uuid");

                    b.HasAlternateKey("Email")
                        .HasName("UK_ReviewerEmail");

                    b.ToTable("Reviewer");
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.Certificate", b =>
                {
                    b.HasOne("PDFOnlineSignature.Models.Reviewer", "Reviewer")
                        .WithOne("Certificate")
                        .HasForeignKey("PDFOnlineSignature.Models.Certificate", "ReviewerUuid");
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.CertificateRequest", b =>
                {
                    b.HasOne("PDFOnlineSignature.Models.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateUuid");

                    b.HasOne("PDFOnlineSignature.Models.Reviewer", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PDFOnlineSignature.Models.Document", b =>
                {
                    b.HasOne("PDFOnlineSignature.Models.Reviewer", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUuid");
                });
#pragma warning restore 612, 618
        }
    }
}
